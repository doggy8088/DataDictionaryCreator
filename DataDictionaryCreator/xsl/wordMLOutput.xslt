<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
                xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml"
                xmlns:wx="http://schemas.microsoft.com/office/word/2003/auxHint">
	<xsl:output method="xml" indent="yes" omit-xml-declaration="no" />
	<xsl:template match="/">
		<xsl:processing-instruction name="mso-application">
			<xsl:text>progid="Word.Document"</xsl:text>
		</xsl:processing-instruction>
		<w:wordDocument>
			<w:body>
				<w:tbl>
					<w:tblPr>
						<w:tblStyle w:val="TableGrid"/>
            <w:tblW w:w="5000" w:type="pct" />
            <w:tblBorders>
              <w:top w:val="single" w:sz="4" wx:bdrwidth="10" w:space="0" w:color="auto"/>
              <w:left w:val="single" w:sz="4" wx:bdrwidth="10" w:space="0" w:color="auto"/>
              <w:bottom w:val="single" w:sz="4" wx:bdrwidth="10" w:space="0" w:color="auto"/>
              <w:right w:val="single" w:sz="4" wx:bdrwidth="10" w:space="0" w:color="auto"/>
              <w:insideH w:val="single" w:sz="6" wx:bdrwidth="15" w:space="0" w:color="auto"/>
              <w:insideV w:val="single" w:sz="6" wx:bdrwidth="15" w:space="0" w:color="auto"/>
            </w:tblBorders>
						<w:tblLook w:val="01E0"/>
					</w:tblPr>
					<w:tblGrid>
					</w:tblGrid>
					<xsl:apply-templates select="documentation/tables/table" />
				</w:tbl>
        <w:p />
				<w:tbl>
					<w:tblPr>
						<w:tblStyle w:val="TableGrid"/>
            <w:tblW w:w="5000" w:type="pct" />
            <w:tblBorders>
              <w:top w:val="single" w:sz="4" wx:bdrwidth="10" w:space="0" w:color="auto"/>
              <w:left w:val="single" w:sz="4" wx:bdrwidth="10" w:space="0" w:color="auto"/>
              <w:bottom w:val="single" w:sz="4" wx:bdrwidth="10" w:space="0" w:color="auto"/>
              <w:right w:val="single" w:sz="4" wx:bdrwidth="10" w:space="0" w:color="auto"/>
              <w:insideH w:val="single" w:sz="6" wx:bdrwidth="15" w:space="0" w:color="auto"/>
              <w:insideV w:val="single" w:sz="6" wx:bdrwidth="15" w:space="0" w:color="auto"/>
            </w:tblBorders>
						<w:tblLook w:val="01E0"/>
					</w:tblPr>
					<w:tblGrid>
					</w:tblGrid>
					<xsl:apply-templates select="documentation/tables/table/column" />
				</w:tbl>
			</w:body>
		</w:wordDocument>
	</xsl:template>

	<xsl:template match="table">
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
              <xsl:value-of select="@schema" />
            </w:t>
          </w:r>
        </w:p>
      </w:tc>
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
							<xsl:value-of select="@description"/>
						</w:t>
					</w:r>
				</w:p>
			</w:tc>
		</w:tr>
	</xsl:template>

	<xsl:template match="column">
		<xsl:if test="position()=1">
			<w:tr >				
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
              <xsl:value-of select="../@schema"/>
            </w:t>
          </w:r>
        </w:p>
      </w:tc>
      <w:tc>
        <w:p>
          <w:r>
            <w:t>
              <xsl:value-of select="../@name"/>
            </w:t>
          </w:r>
        </w:p>
      </w:tc>
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
