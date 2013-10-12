<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml" xmlns:aml="http://schemas.microsoft.com/aml/2001/core">
  <xsl:output method="xml" indent="yes" omit-xml-declaration="no" />  
	<xsl:template match="/">
		<xsl:processing-instruction name="mso-application">
			<xsl:text>progid="Word.Document"</xsl:text>
		</xsl:processing-instruction>
    <w:wordDocument xml:space="preserve">      
			<w:body>
        <w:tbl>
          <w:tblPr>
            <w:tblStyle w:val="TableGrid"/>
            <w:tblW w:w="5000" w:type="pct" />
            <w:tblLook w:val="01E0"/>
            <w:tblBorders>
              <w:top w:val="single" w:sz="4" w:bdrwidth="10" w:space="0" w:color="auto"/>
              <w:left w:val="single" w:sz="4" w:bdrwidth="10" w:space="0" w:color="auto"/>
              <w:bottom w:val="single" w:sz="4" w:bdrwidth="10" w:space="0" w:color="auto"/>
              <w:right w:val="single" w:sz="4" w:bdrwidth="10" w:space="0" w:color="auto"/>
              <w:insideH w:val="single" w:sz="4" w:bdrwidth="10" w:space="0" w:color="auto"/>
              <w:insideV w:val="single" w:sz="4" w:bdrwidth="10" w:space="0" w:color="auto"/>
            </w:tblBorders>
          </w:tblPr>
          <w:tblGrid>
          </w:tblGrid>
          <xsl:call-template name="TablesHead" />
        </w:tbl>        
        <w:p />        
        <xsl:apply-templates select="documentation/tables/table" />        
			</w:body>
		</w:wordDocument>
	</xsl:template>

  <xsl:template name="TablesHead">
    <xsl:for-each select="documentation/tables/table">
        <xsl:if test="position()=1">
          <w:tr>
            <w:tc>
              <w:p>
                <w:r>
                  <w:rPr>
                    <w:b w:val="on"/>
                  </w:rPr>
                  <w:t>Schema</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:p>
                <w:r>
                  <w:rPr>
                    <w:b w:val="on"/>
                  </w:rPr>
                  <w:t>Table</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:p>
                <w:r>
                  <w:rPr>
                    <w:b w:val="on"/>
                  </w:rPr>
                  <w:t>Description</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
        </xsl:if>
        <w:tr>
          <w:tc>
            <w:p>
              <w:r>
                <w:t>
                  <xsl:value-of select="@schema"/>
                </w:t>
              </w:r>
            </w:p>
          </w:tc>
          <w:tc>
            <w:p>
              <w:hlink w:bookmark="anchor_{@schema}.{@name}">
                <xsl:value-of select="@name" />
                <w:r>
                  <w:rPr>
                    <w:rStyle w:val="Hyperlink" />
                    <w:color w:val="0000FF" />
                    <w:u w:val="single" />
                  </w:rPr>
                  <w:t>
                    <xsl:value-of select="@name" />
                  </w:t>
                </w:r>
              </w:hlink>
            </w:p>
          </w:tc>
          <w:tc>
            <w:p>
              <w:r>
                <w:t>
                  <xsl:value-of select="@description"/>
                </w:t>
              </w:r>
            </w:p>
          </w:tc>
        </w:tr>
    </xsl:for-each>
  </xsl:template>
  
	<xsl:template match="table">
    <w:p/>
    <w:p>
      <w:r>
        <w:rPr>
          <w:b w:val="on"/>
        </w:rPr>
        <w:t>[<xsl:value-of select="@schema"/>].[<xsl:value-of select="@name"/>]: </w:t>
        <aml:annotation aml:id="0" w:type="Word.Bookmark.Start" w:name="anchor_{@schema}.{@name}">
          <xsl:value-of select="@name"/>
        </aml:annotation>
        <aml:annotation aml:id="0" w:type="Word.Bookmark.End"/>
      </w:r>      
      <w:r>
        <w:t>
          <xsl:value-of select="@description"/>
        </w:t>        
      </w:r>
    </w:p>
    <w:tbl>
      <w:tblPr>
        <w:tblStyle w:val="TableGrid"/>
        <w:tblW w:w="5000" w:type="pct" />
        <w:tblLook w:val="01E0"/>
        <w:tblBorders>
          <w:top w:val="single" w:sz="4" w:bdrwidth="10" w:space="0" w:color="auto"/>
          <w:left w:val="single" w:sz="4" w:bdrwidth="10" w:space="0" w:color="auto"/>
          <w:bottom w:val="single" w:sz="4" w:bdrwidth="10" w:space="0" w:color="auto"/>
          <w:right w:val="single" w:sz="4" w:bdrwidth="10" w:space="0" w:color="auto"/>
          <w:insideH w:val="single" w:sz="4" w:bdrwidth="10" w:space="0" w:color="auto"/>
          <w:insideV w:val="single" w:sz="4" w:bdrwidth="10" w:space="0" w:color="auto"/>
        </w:tblBorders>
      </w:tblPr>
      <w:tblGrid>
      </w:tblGrid>
      <xsl:apply-templates select="column" />
    </w:tbl>
	</xsl:template>

	<xsl:template match="column">
		<xsl:if test="position()=1">
			<w:tr>				
				<w:tc>
					<w:p>
            <w:r>
              <w:rPr>
                <w:b w:val="on"/>
              </w:rPr>
							<w:t>Column</w:t>
						</w:r>
					</w:p>
				</w:tc>
				<w:tc>
					<w:p>
						<w:r>
              <w:rPr>
                <w:b w:val="on"/>
              </w:rPr>
							<w:t>Datatype</w:t>
						</w:r>
					</w:p>
				</w:tc>
        <w:tc>
          <w:p>
            <w:r>
              <w:rPr>
                <w:b w:val="on"/>
              </w:rPr>
              <w:t>Size</w:t>
            </w:r>
          </w:p>
        </w:tc>
        <w:tc>
          <w:p>
            <w:r>
              <w:rPr>
                <w:b w:val="on"/>
              </w:rPr>
              <w:t>Nullable</w:t>
            </w:r>
          </w:p>
        </w:tc>
        <w:tc>
          <w:p>
            <w:r>
              <w:rPr>
                <w:b w:val="on"/>
              </w:rPr>
              <w:t>InPrimaryKey</w:t>
            </w:r>
          </w:p>
        </w:tc>
        <w:tc>
          <w:p>
            <w:r>
              <w:rPr>
                <w:b w:val="on"/>
              </w:rPr>
              <w:t>IsForeignKey</w:t>
            </w:r>
          </w:p>
        </w:tc>
				<w:tc>
					<w:p>
						<w:r>
              <w:rPr>
                <w:b w:val="on"/>
              </w:rPr>
							<w:t>Description</w:t>
						</w:r>
					</w:p>
				</w:tc>
				<xsl:for-each select="property">
					<w:tc>
						<w:p>
							<w:r>
                <w:rPr>
                  <w:b w:val="on"/>
                </w:rPr>
								<w:t>
									<xsl:value-of select="@name"/>
								</w:t>
							</w:r>
						</w:p>
					</w:tc>
				</xsl:for-each>
			</w:tr>
		</xsl:if>
		<w:tr>			
			<w:tc>
				<w:p>
					<w:r>
						<w:t>
							<xsl:value-of select="@name" />
						</w:t>
					</w:r>
				</w:p>
			</w:tc>
			<w:tc>
				<w:p>
					<w:r>
						<w:t>
							<xsl:value-of select="@datatype" />
						</w:t>
					</w:r>
				</w:p>
			</w:tc>
      <w:tc>
        <w:p>
          <w:r>
            <w:t>
              <xsl:value-of select="@size" />
            </w:t>
          </w:r>
        </w:p>
      </w:tc>
      <w:tc>
        <w:p>
          <w:r>
            <w:t>
              <xsl:value-of select="@nullable" />
            </w:t>
          </w:r>
        </w:p>
      </w:tc>
      <w:tc>
        <w:p>
          <w:r>
            <w:t>
              <xsl:value-of select="@inprimarykey" />
            </w:t>
          </w:r>
        </w:p>
      </w:tc>
      <w:tc>
        <w:p>
          <w:r>
            <w:t>
              <xsl:value-of select="@isforeignkey" />
            </w:t>
          </w:r>
        </w:p>
      </w:tc>
			<w:tc>
				<w:p>
					<w:r>
						<w:t>
							<xsl:value-of select="@description"/>
						</w:t>
					</w:r>
				</w:p>
			</w:tc>
			<xsl:apply-templates select="property" />
		</w:tr>
	</xsl:template>

	<xsl:template match="property">
		<w:tc>
			<w:p>
				<w:r>
					<w:t>
						<xsl:value-of select="@value"/>
					</w:t>
				</w:r>
			</w:p>
		</w:tc>
	</xsl:template>

</xsl:stylesheet>
